abp install-libs

cd src/otomasyonstudent.DbMigrator && dotnet run && cd -

cd src/otomasyonstudent.Blazor && dotnet dev-certs https -v -ep openiddict.pfx -p 87e8362a-ccaa-47fa-8f2d-9ea964ac5b7e




exit 0