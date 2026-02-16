
---

# Entity Framework Setup Guide

## Code-First

Using **Package Manager Console** (`Console du Gestionnaire de package`):

```powershell
Add-Migration Initial
```

> ⚠️ If `InvariantGlobalization` is set to `true` in your `.csproj` file, set it to `false` before running migrations:

```xml
<InvariantGlobalization>false</InvariantGlobalization>
```

Then apply the migration:

```powershell
Update-Database
```

---

## Database-First

### Required NuGet Packages

Install the following packages:

* `Microsoft.EntityFrameworkCore`
* `Microsoft.EntityFrameworkCore.Tools`
* `Microsoft.EntityFrameworkCore.SqlServer`

---

### Scaffold the Database

Using **Package Manager Console**:

```powershell
Scaffold-DbContext "Server=DESKTOP-6IV8GIO\SQLEXPRESS;Database=databasename;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context AppDbContext
```

This generates:

* `DbContext`
* Entity classes
* Fluent mappings

---

### Enable Code-Based Migrations After Scaffolding

After scaffolding, you can enable migrations:

```powershell
Add-Migration InitialCreate
```

If the database already exists and matches the model:

```powershell
Update-Database
```

This will create the `__EFMigrationsHistory` table without recreating existing tables.

---

# Notes

* After switching to migrations, **do not re-run `Scaffold-DbContext`**, as it will overwrite your changes.
* Once migrations are enabled, the **C# model becomes the source of truth**, not the database.

---


# ✅ Référencer projet principal depuis projet de test

### Étapes :

1. **Clic droit sur le projet de test**
2. 👉 **Ajouter**
3. 👉 **Référence de projet…**
4. Coche le **projet principal** (ex: `SuperHeroAPI_DotNet8`)
5. Clique sur **OK**



---

