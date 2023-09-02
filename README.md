# nexus-api

API Hackathon Samba Meets

# Migrate and Update Database
`Add-Migration UserMigrate -Context UserDb`
`Add-Migration UserMigrate -Context CompanyDb`
`Add-Migration UserMigrate -Context ProjectDb`

`Update-Database -Context UserDb`
`Update-Database -Context CompanyDb`
`Update-Database -Context ProjectDb`
