//using IdentityExample.Models;
//using Microsoft.AspNetCore.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace IdentityExample.Infrastructure
//{
//    // public class CustomUserValidator:IUserValidator<AppUser>
//    public class CustomUserValidator : UserValidator<AppUser>
//    {
//        //  public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager,
//        //      AppUser user)
//        // {
//        public override async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager,
//            AppUser user)
//        {
//            IdentityResult result = await base.ValidateAsync(manager, user);
//            List<IdentityError> errors = result.Succeeded ?
//                new List<IdentityError>() : result.Errors.ToList();

//            if (!user.Email.ToLower().EndsWith("@gmail.com"))
//            {
//                errors.Add(new IdentityError
//                {
//                    Code = "EmailDomainError",
//                    Description = "Only gmail.com email address"
//                });
//            }
//            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
//            //if (user.Email.ToLower().EndsWith("@gmail.com"))
//            //{
//            //    return Task.FromResult(IdentityResult.Success);
//            //}
//            //else
//            //{
//            //    return Task.FromResult(IdentityResult.Failed(new IdentityError
//            //    {
//            //        Code = "EmailDomainError",
//            //        Description = "Only gmail.com email address"

//            //    }));
//        }
//    }
//}

