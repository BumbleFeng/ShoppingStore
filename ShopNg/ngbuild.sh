cd ShopNg/ShopClient
npm install
ng build --prod
cd dist
zip dist.zip * -r
cd ../../../
mv -f ShopNg/ShopClient/dist/dist.zip ubuntu/dist.zip