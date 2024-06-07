﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using EmailApp.Enums;
using EmailApp.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmailApp.Models;

public partial class Email
{
    public int EmailId { get; set; }

    [Required]
    [CustomEmail]
    public string FromEmail { get; set; }

    [Required]
    [CustomEmail]
    public string ToEmail { get; set; }

    [MultipleEmailAddresses]
    public List<string> CcEmails { get; set; } = new List<string>();

    [Required]
    [StringLength(100, ErrorMessage = "Subject length can't be more than 100 characters.")]
    public string Subject { get; set; }

    [Required]
    public Importance Importance { get; set; }

    [Required]
    [StringLength(1000, ErrorMessage = "Content length can't be more than 1000 characters.")]
    public string Content { get; set; }

    public DateTime CreatedDate { get; set; }
}