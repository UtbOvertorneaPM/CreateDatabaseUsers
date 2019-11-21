using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordHasher {

    interface IValidator<T> where T : class {

        bool Validate(T entity);
    }
}
