authApi="NetCore.Microservices.Services.AuthApi"
couponApi="NetCore.Microservices.Services.CouponApi"
emailApi="NetCore.Microservices.Services.EmailApi"
orderApi="NetCore.Microservices.Services.OrderApi"
productApi="NetCore.Microservices.Services.ProductApi"
rewardApi="NetCore.Microservices.Services.RewardApi"
shoppingCartApi="NetCore.Microservices.Services.ShoppingCartApi"

core="NetCore.WebApiCommon.Core"
coreCommon="NetCore.WebApiCommon.Core.Common"
coreDAL="NetCore.WebApiCommon.Core.DAL"
coreApi="NetCore.WebApiCommon.Core.Api"
infrastructure="NetCore.WebApiCommon.Infrastructure"


apiList=($authApi $couponApi $emailApi $orderApi $productApi $rewardApi $shoppingCartApi)
packageList=($core $coreCommon $coreDAL $coreApi $infrastructure)

for api in ${apiList[@]}; do
	for packageName in ${packageList[@]}; do
		(cd ..; dotnet add $api package $packageName)
	done
done
