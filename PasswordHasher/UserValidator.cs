using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordHasher {

    class UserValidator : IValidator<IUser> {

        public bool Validate(IUser entity) {

            var isValid = true;

            if (entity is null) {

                isValid = false;    
            }
            else if (string.IsNullOrEmpty(entity.Name)) {

                isValid = false;
            }
            else if (string.IsNullOrEmpty(entity.Password)) {

                isValid = false;
            }

            return isValid;
        }
    }
}
