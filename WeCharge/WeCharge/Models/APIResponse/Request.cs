using System;
using WeCharge.ApiService.EndPoints;

namespace WeCharge.Models.APIResponse
{
    public class Request
    {
        /// <summary>
        /// Email of the Lotus user logging in.
        /// </summary>
        public string Email { get; set; } = "";
        /// <summary>
        /// The user's clear text password.
        /// </summary>
        public string Password { get; set; } = "";
    }
}

