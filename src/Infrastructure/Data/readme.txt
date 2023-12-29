Remove Migrations
dotnet ef --startup-project ../Application migrations remove

Add Migrations
dotnet ef --startup-project ../Application migrations add NOME_DA_MIGRATION  --output-dir Data/Migrations

Update Database
dotnet ef database update  --startup-project ../Application                                              