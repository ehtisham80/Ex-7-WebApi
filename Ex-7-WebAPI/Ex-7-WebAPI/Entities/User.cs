﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Ex_7_WebAPI.Entities
{
    public class User
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public byte PasswordHash { get; set; }

        [Required]
        public byte PasswordSalt { get; set; }


        public void CreatePasswordHash(string password)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i=0; i< computedHash.Lenght; i++)
                {
                    if (computedHash[i] != PasswordHash[i])
                        return false;
                }
            }
            return true;
        }
    }
}
