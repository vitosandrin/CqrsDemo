﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.Domain.Validation;

public class DomainValidation(string error) : Exception(error)
{
    public static void When(bool hasError, string error)
    {
        if (hasError)
        {
            throw new DomainValidation(error);
        }
    }
}
