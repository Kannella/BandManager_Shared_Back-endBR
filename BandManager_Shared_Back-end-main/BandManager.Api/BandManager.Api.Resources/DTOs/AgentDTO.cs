using System.ComponentModel.DataAnnotations;
using BandManager.Api.Resources.Models;

namespace BandManager.Api.Resources.DTOs;

public class AgentDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    public Agent ToEntity()
    {
        return new Agent
        {
            Name = Name,
            Email = Email,
            PhoneNumber = PhoneNumber
        };
    }
}