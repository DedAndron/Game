using System;
using System.Collections.Generic;
using System.Text;

namespace SystemPrograming
{
    public class BankAccount
    {
        private decimal _balance;
        private readonly object _locker = new object();
        private bool _isBlocked = false;
        public BankAccount(decimal initialBalance)
        {
            _balance = initialBalance;
        }
        public void Deposit(decimal amount)
        {
            lock (_locker)
            {
                if (_isBlocked) return;

                _balance += amount;
                Console.WriteLine($"Deposit: {amount}, Balance: {_balance}");
            }
        }
        public void Withdraw(decimal amount)
        {
            lock (_locker)
            {
                if (_isBlocked) return;

                if (_balance >= amount)
                {
                    _balance -= amount;
                    Console.WriteLine($"Withdraw: {amount}, Balance: {_balance}");
                }
                else
                {
                    Console.WriteLine("Not enough money");
                }
            }
        }
        public void Block()
        {
            lock (_locker)
            {
                _isBlocked = true;
                Console.WriteLine("Account blocked!");
            }
        }
        public decimal GetBalance()
        {
            return _balance;
        }
    }
}
