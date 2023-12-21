readonly AUTH_API="NetCore.Microservices.Services.AuthApi"
readonly COUPON_API="NetCore.Microservices.Services.CouponApi"
readonly EMAIL_API="NetCore.Microservices.Services.EmailApi"
readonly ORDER_API="NetCore.Microservices.Services.OrderApi"
readonly PRODUCT_API="NetCore.Microservices.Services.ProductApi"
readonly REWARD_API="NetCore.Microservices.Services.RewardApi"
readonly SHOPPING_CART_API="NetCore.Microservices.Services.ShoppingCartApi"

readonly CORE="NetCore.WebApiCommon.Core"
readonly CORE_COMMON="NetCore.WebApiCommon.Core.Common"
readonly CORE_DAL="NetCore.WebApiCommon.Core.DAL"
readonly CORE_API="NetCore.WebApiCommon.Core.Api"
readonly INFRASTRUCTURE="NetCore.WebApiCommon.Infrastructure"


apiList=($AUTH_API $COUPON_API $EMAIL_API $ORDER_API $PRODUCT_API $REWARD_API $SHOPPING_CART_API)
packageList=($CORE $CORE_COMMON $CORE_DAL $CORE_API $INFRASTRUCTURE)

for api in ${apiList[@]}; do
	for packageName in ${packageList[@]}; do
		(cd ..; dotnet add $api package $packageName)
	done
done
