#!/bin/sh

LOCATION=$1
SECRET_PASSPHRASE=$2
gpg --quiet --batch --yes --decrypt --passphrase="$SECRET_PASSPHRASE" --output "$LOCATION"/appsettings.Production.json "$LOCATION"/appsettings.Production.json.gpg
