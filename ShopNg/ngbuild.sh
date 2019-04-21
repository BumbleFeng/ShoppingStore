cd ShopNg/ShopClient
npm install
ng build --prod
ng build --prod --output-path docs --base-href /ShoppingStore/
cd dist
zip dist.zip * -r
cd ../../../
mv -f ShopNg/ShopClient/dist/dist.zip ubuntu/dist.zip
cd ../
rm -r docs
mv ShopNg/ShopNg/ShopClient/docs docs
cd docs
cp index.html 404.html