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
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

using HCatalystProjectCostsSite.Enums;

namespace HCatalystProjectCostsSite.Models;

public class Cost
{
    public Submission details { get; set; } = new();
    public float amount { get; set; }
    public bool recurring { get; set; }
    public Basis basis { get; set; }
    public CostType costType { get; set; }

    public float AnnualCost()
    {
        switch (basis)
        {
            case Basis.Annually:
                return amount;
            case Basis.BiAnnually:
                return amount * 2f;
            case Basis.Quarterly:
                return amount * 4f;
            case Basis.Monthly:
                return amount * 12f;
            case Basis.BiMonthly:
                return amount * 24f;
            case Basis.Weekly:
                return amount * 52f;
            case Basis.Daily:
                return amount * 365f;
            case Basis.Hourly:
                return amount * 365f * 24f;
        }
        return 0f;
    }

    public float CostOverPeriod(int years)
    {
        return AnnualCost() * years;
    }
}