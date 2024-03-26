﻿using OnlineRivalMarket.Domain.Abstractions;

namespace OnlineRivalMarket.Domain.CompanyEntities;
public class FieldInformation : Entity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime? Date { get; set; }
    public string? Location { get; set; }
    public string? Source { get; set; }
}