// HCatalyst_ProjectCostingSite -- HelperFuncs.cs
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

namespace HCatalystProjectCostsSite.Helpers;

public static class HelperFuncs
{
    public static List<Basis> BasisEnums()
    {
        return new List<Basis>()
        {
            Basis.None,
            Basis.Annually,
            Basis.BiAnnually,
            Basis.Quarterly,
            Basis.Monthly,
            Basis.BiMonthly,
            Basis.Weekly,
            Basis.Daily,
            Basis.Hourly
        };
    }
}