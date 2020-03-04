﻿using Scaffold.Domain.Core.Commands;
using Scaffold.Domain.Models.Product;
using System;
using System.Linq.Expressions;

namespace Scaffold.Domain.Models.Cart.Commands
{
    public sealed class CartCreateCommand : CartCommand
    {
        public CartCreateCommand(Cart cart)
            : base(cart)
        {

        }

        public override bool IsValid()
        {
            Validator.ValidateCustomerId();
            Validator.ValidateItem();

            return Validate(Validator, this);
        }
    }
}
