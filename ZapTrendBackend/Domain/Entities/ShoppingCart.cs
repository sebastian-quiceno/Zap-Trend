using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using ZapTrendBackend.Model.Enums;
using ZapTrendBackend.Model.Events;

namespace ZapTrendBackend.Model.Entities
{
    public class ShoppingCart
    {
        //Atributos

        // Usamos el tipo genérico EventHandler pasando nuestros argumentos personalizados.
        // El signo '?' indica que puede ser nulo si nadie se ha suscrito todavía.
        public event EventHandler<CartStatusChangedEventArgs>? StatusChanged;
        public Guid Id { get; private set; }
        private User user;
        private List<CartItem> cartItems;
        private DateTime date;
        private decimal subtotal;
        private CartStatus status;

        //Contructores
        //Constructor ambiguo
        private ShoppingCart(Guid id, User user, List<CartItem> cartItems, DateTime date, decimal subtotal, CartStatus status)
        {
            Id = id;
            User = user;
            CartItems = cartItems;
            Date = date;
            this.subtotal = subtotal;
            this.status = status;
        }

        //Metodos Constructores
        public static ShoppingCart Create(User user) {
            return new ShoppingCart(Guid.NewGuid(), user, new List<CartItem>(), DateTime.Now, 0, CartStatus.PENDING);
        }

        public static ShoppingCart Recreate(Guid id, User user, List<CartItem> cartItems, DateTime date, decimal subtotal, CartStatus cartStatus){
            return new ShoppingCart(id, user, cartItems, date, subtotal, cartStatus);
        }

        public User User { 
            get => user;
            private set {
                if (value is null)
                    throw new ArgumentException("El Usuario en Shoping Cart no puede ser nulo");
                user = value;
            }        
        }
        public List<CartItem> CartItems { get => cartItems; private set => cartItems = value; }
        public DateTime Date { get => date; private set => date = value; }
        public decimal Subtotal { 
            get => subtotal;
            private set {
                if (subtotal < 0)
                    throw new ArgumentException("El subtotal del Carro de compras no puede ser nulo");
                subtotal = value;
            } 
        }
        public CartStatus Status { get => status; private set => status = value; }

        //Metodos
        public void AddItem(CartItem cartItem) {
            cartItems.Add(cartItem);
            CalculateTotal();
        }
        public void RemoveItem(CartItem item)
        {
            cartItems.Remove(item);
            CalculateTotal();
        }

        public void ChangeStatusConfirm()
        {
            if (status == CartStatus.CONFIRMED) return;

            status = CartStatus.CONFIRMED;

            // Se crea la "maleta" con los datos necesarios (ID y nuevo estado)
            var args = new CartStatusChangedEventArgs(Id, status);

            // 3. Disparamos el evento de forma segura
            OnStatusChanged(args);
        }

        // Método protegido virtual para disparar el evento (buena práctica en C#)
        protected virtual void OnStatusChanged(CartStatusChangedEventArgs eventArgs)
        {
            StatusChanged?.Invoke(this, eventArgs);
        }

        public void changeStatusCancel()
        {
            Status = CartStatus.CANCELLED;
        }

        private void CalculateTotal() {

            if (cartItems.Count == 0) {
                Subtotal = 0;
                return;
            }

            subtotal = cartItems.Sum(i => i.CalculateTotal());
        }


    }
}
