// HCatalyst_ProjectCostingSite -- ConversionService.cs
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

using System.Net.Http.Json;
using HCatalystProjectCostsSite.Helpers;
using HCatalystProjectCostsSite.Models;

namespace HCatalystProjectCostsSite.Services;

public class ConversionService
{
    public HttpClient http { get; set; }
    public ConversionRates? conversionRates { get; private set; }    

    public ConversionService(HttpClient httpClient)
    {
        http = httpClient;
        InitAsync();
    }

    private async Task InitAsync()
    {
        conversionRates = await http.GetFromJsonAsync<ConversionRates>(PathHelper.getConvRatesConnString);
    }
}