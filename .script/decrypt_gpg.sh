#! /bin/bash
readonly AUTH_API="NetCore.Microservices.Services.AuthApi"
readonly COUPON_API="NetCore.Microservices.Services.CouponApi"

apiList=("$AUTH_API" "$COUPON_API")

for api in "${apiList[@]}"; do
	gpg --quiet --batch --yes --decrypt --passphrase="$SECRET_PASSPHRASE" --output "$api"/appsettings.Production.json "$api"/appsettings.Production.json.gpg
done
