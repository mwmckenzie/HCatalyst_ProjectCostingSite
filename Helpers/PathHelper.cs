// HCatalyst_ProjectCostingSite -- PathHelper.cs
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

namespace HCatalystProjectCostsSite.Helpers;

public static class PathHelper
{
    public const string assumptionsGetConnString =
        "https://hcatalystcostsprojectapi.azurewebsites.net/api/assumption?code=8aIQhCaSKX50x01QwONuzyWZ3NI8H3PfVBNYoGhch57ZAzFuKthrtQ==";

    public const string assumptionPostConnString = 
        "https://hcatalystcostsprojectapi.azurewebsites.net/api/assumption?code=eBqfFubQ5gYiWft6WiubbpC7RWI8NXm4arARagAJXImOAzFuF2xHaQ==";

    public const string costsGetConnString =
        "https://hcatalystcostsprojectapi.azurewebsites.net/api/cost?code=LcXc8ghDMVKZGUE7cYByVHvY-h9RgYtM9bk6_gqSbYeJAzFuRg1tlw==";

    public const string costPostConnString =
        "https://hcatalystcostsprojectapi.azurewebsites.net/api/cost?code=hFyg4sLPK80q4n-LY0HjYkqbDc064NerHdD4y9ayLFOFAzFuDF95Mw==";


    public const string costDeleteSuffix = "Z7eDzkANLU_s1GpMHyylOS82DKPfaBYUQ2KjWJ2n4ODFAzFuOymztQ==";
    public const string costGetByIdSuffix = "s52Pfp6KaoAxhBrs6jgE4n-F-a74wM4aHeJjvbaZiAL2AzFugUgfEQ==";
    public const string costUpsertByIdSuffix = "BfN4gz1NkRdJLSeVL_6XP_3UoH1rzqxM7Go6iypyDWUAAzFuWboDMg==";


    public static string GetCostDeleteConnString(string id)
    {
        return
            $"https://hcatalystcostsprojectapi.azurewebsites.net/api/cost/{id}?code=Z7eDzkANLU_s1GpMHyylOS82DKPfaBYUQ2KjWJ2n4ODFAzFuOymztQ==";
    }

    public static string GetCostByIdConnString(string id)
    {
        return
            $"https://hcatalystcostsprojectapi.azurewebsites.net/api/cost/{id}?code=s52Pfp6KaoAxhBrs6jgE4n-F-a74wM4aHeJjvbaZiAL2AzFugUgfEQ==";
    }
    
    public static string UpsertCostByIdConnString(string id)
    {
        return
            $"https://hcatalystcostsprojectapi.azurewebsites.net/api/cost/{id}?code=BfN4gz1NkRdJLSeVL_6XP_3UoH1rzqxM7Go6iypyDWUAAzFuWboDMg==";
    }
    
    public static string TemplateCostConnString(string id, string connStrSuffix)
    {
        return $"https://hcatalystcostsprojectapi.azurewebsites.net/api/cost/{id}?code={connStrSuffix}";
    }

    public const string getConvRatesConnString = 
        "https://hcatalystcostsprojectapi.azurewebsites.net/api/conversionRates?code=8nTq9qDFGWi7mUf3D4ajNfthNsJL-5KYZjsr-nfiHVSqAzFuetyHJw==";

    // public static string BuildBaseApiPath(string name)
    // {
    //     return  $"{serviceEndpoint}{name}{hostKeyPrefix}{hostKey}";
    // }
}