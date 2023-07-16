// HCatalyst_ProjectCostingSite -- Cost.cs
// 
// Copyright (C) 2023 Matthew W. McKenzie and Kenz LLC
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more assumption.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using HCatalystProjectCostsSite.Enums;

namespace HCatalystProjectCostsSite.Models;

public class Cost
{
    
    public string id { get; set; } = Guid.NewGuid().ToString();
    public Submission submission { get; set; } = new();
    public Currency currency { get; set; } = Currency.USD;
    
    public decimal costInitial { get; set; }
    
    public decimal costRecurring { get; set; }
    public Basis basis { get; set; }
    public int basisCount { get; set; }
    
    public AssociatedRole associatedRole { get; set; }
    public int associatedRoleCount { get; set; } = 1;
    
    public CostEvent costEvent { get; set; }
    public int EventCount { get; set; } = 1;
    
    public CostPhase costPhase { get; set; }
    public CostType costType { get; set; }
    
    public bool recurring => basis > Basis.None;

    private ConversionRates? _conversionRates = new();
    public void SetRates(ConversionRates? rates) => _conversionRates = rates;
    
    public decimal CostInitialInUsd()
    {
        return currency switch
        {
            Currency.USD => costInitial,
            Currency.GBP => _conversionRates.GbpToUsd * costInitial,
            Currency.EUR => _conversionRates.eurToUsd * costInitial,
            _ => costInitial
        };
    }
    
    public decimal CostTotalInUsd()
    {
        return currency switch
        {
            Currency.USD => CostSubtotal(),
            Currency.GBP => _conversionRates.GbpToUsd * CostSubtotal(),
            Currency.EUR => _conversionRates.eurToUsd * CostSubtotal(),
            _ => CostSubtotal()
        };
    }
    
    public decimal CostInUsd(ConversionRates rates)
    {
        return currency switch
        {
            Currency.USD => CostSubtotal(),
            Currency.GBP => rates.usdToGbp * CostSubtotal(),
            Currency.EUR => rates.usdToEur * CostSubtotal(),
            _ => CostSubtotal()
        };
    }
    
    public decimal AnnualCost()
    {
        switch (basis)
        {
            case Basis.Annually:
                return costRecurring;
            case Basis.BiAnnually:
                return costRecurring * 2m;
            case Basis.Quarterly:
                return costRecurring * 4m;
            case Basis.Monthly:
                return costRecurring * 12m;
            case Basis.BiMonthly:
                return costRecurring * 24m;
            case Basis.Weekly:
                return costRecurring * 52m;
            case Basis.Daily:
                return costRecurring * 365m;
            case Basis.Hourly:
                return costRecurring * 365m * 24m;
        }
        return 0m;
    }

    public decimal CostOverPeriod(decimal years)
    {
        return costInitial + AnnualCost() * years;
    }
    
    public decimal CostSubtotalPeriod()
    {
        return costInitial + costRecurring * MinOne(basisCount);
    }

    public decimal CostSubtotalPeriodRoles()
    {
        return CostSubtotalPeriod() * MinOne(associatedRoleCount);
    }

    public decimal CostSubtotal()
    {
        return CostSubtotalPeriodRoles() * MinOne(EventCount);
    }

    private int MinOne(int num)
    {
        return num < 1 ? 1 : num;
    }
}