// HCatalyst_ProjectCostingSite -- ConversionRates.cs
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

namespace HCatalystProjectCostsSite.Models;

public class ConversionRates
{
    public bool success { get; set; }
    public int timestamp { get; set; }
    public string @base { get; set; }
    public string date { get; set; }
    public Rates rates { get; set; }
    
    public decimal eurToUsd => rates.USD;
    public decimal usdToEur =>  1m / eurToUsd;
    
    public decimal usdToGbp =>  rates.GBP * usdToEur;
    public decimal GbpToUsd =>  1m / usdToGbp;
}