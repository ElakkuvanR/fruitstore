import React, { useEffect, useState, useContext } from "react";
import ProductCard from "./ProductCard";
import useHttp from "../../hooks/use-http";
import AuthContext from "../../store/auth-context";
import { EnvironmentConfig } from "../../environments/environmentconfig";

const getPrice = (priceData) => {
  const priceBreaks = priceData.PriceBreaks;
  if (priceBreaks.length > 0) return priceBreaks[0].Price;
  else return 0;
};

const formImageUrl = (imageProp) => {
  const firebaseDomain = EnvironmentConfig.firebaseUrl;
  let imageUrl = "";
  if (imageProp) {
    imageUrl =
      firebaseDomain + `${imageProp.name}?alt=media&token=${imageProp.token}`;
  }
  return imageUrl;
};

const ProductList = () => {
  const { sendRequest: fetchProducts, error: httpError } = useHttp();
  const [meProducts, setMeProducts] = useState([]);
  const [isLoading, setIsLoading] = useState(true);
  const ctx = useContext(AuthContext);

  useEffect(() => {
    const transformProducts = (productObj) => {
      const allProducts = [];

      for (const key in productObj.Items) {
        allProducts.push({
          id: productObj.Items[key].ID,
          name: productObj.Items[key].Name,
          description: productObj.Items[key].Description,
          price: getPrice(productObj.Items[key].PriceSchedule),
          img: formImageUrl(productObj.Items[key].xp.image),
        });
      }
      setMeProducts(allProducts);
      setIsLoading(false);
    };

    fetchProducts(
      {
        url: EnvironmentConfig.apiMiddlewareUrl + "products/list",
        method: "GET",
        headers: {
          "Content-Type": "application/json",
          Authorization: "Bearer " + ctx.authToken,
        },
      },
      transformProducts
    );
  }, [ctx.authToken, fetchProducts]);

  return (
    <section className="bg-white py-8">
      <div className="container mx-auto flex items-center flex-wrap pt-4 pb-12">
        {meProducts.map((product) => (
          <ProductCard
            name={product.name}
            price={product.price}
            imgurl={product.img}
            key={product.id}
          ></ProductCard>
        ))}
      </div>
    </section>
  );
};

export default ProductList;
