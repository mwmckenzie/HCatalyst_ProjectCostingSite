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
// GNU General Public License for more submission.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using HCatalystProjectCostsSite.Enums;

namespace HCatalystProjectCostsSite.Models;

public class Cost
{
    public string id { get; set; } = Guid.NewGuid().ToString();
    public Submission submission { get; set; } = new();
    public decimal cost { get; set; }
    public decimal costRecurring { get; set; }
    public Currency currency { get; set; } = Currency.USD;
    public Basis basis { get; set; }
    public CostPhase costPhase { get; set; }
    // public float cost { get; set; }
    // public float costRecurring { get; set; }

    public bool recurring => basis > Basis.None;
    
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
        return cost + AnnualCost() * years;
    }
}