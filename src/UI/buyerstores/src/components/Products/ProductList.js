import React from "react";
import ProductCard from "./ProductCard";
import Filter from "./Filter";
import PreviousMap from "postcss/lib/previous-map";

const DUMMY_PRODUCTS = [
  {
    id: "fs_001",
    name: "Banana",
    description: "Pack of 8 premium Bananas",
    price: 10,
    img:"https://firebasestorage.googleapis.com/v0/b/react-http-51a82.appspot.com/o/fs_01.jpg?alt=media&token=a6de9dca-6274-4df4-a063-a86c4bc713ae"
  },
  {
    id: "fs_002",
    name: "Grapes",
    description: "Pack of 1 Kg Grapes",
    price: 45,
    img:"https://firebasestorage.googleapis.com/v0/b/react-http-51a82.appspot.com/o/fs_02.jpg?alt=media&token=d36e740a-931e-43af-bbbf-8acd8326dbc1"
  },
  {
    id: "fs_003",
    name: "Green Apple",
    description: "Pack of 4 premium Bananas",
    price: 23,
    img:"https://firebasestorage.googleapis.com/v0/b/react-http-51a82.appspot.com/o/fs_03.jpg?alt=media&token=914a0df6-6309-4680-9862-0196e64fae35"
  },
  {
    id: "fs_004",
    name: "Kiwi",
    description: "1 Kg Europian Kiwi",
    price: 43,
    img:"https://firebasestorage.googleapis.com/v0/b/react-http-51a82.appspot.com/o/fs_04.jpg?alt=media&token=28c5aa0a-0785-4085-8fa4-045901b4d418"
  },
  {
    id: "fs_005",
    name: "Lemons",
    description: "Pack of 8 premium Lemons",
    price: 10,
    img:"https://firebasestorage.googleapis.com/v0/b/react-http-51a82.appspot.com/o/fs_05.jpg?alt=media&token=a1e56924-b076-48fd-b50b-d24a3c1bdbfc"
  },
  {
    id: "fs_006",
    name: "Mangoes",
    description: "Pack of 3 premium Mangoes",
    price: 24,
    img:"https://firebasestorage.googleapis.com/v0/b/react-http-51a82.appspot.com/o/fs_06.jpg?alt=media&token=522539a5-d5e1-4649-9a1d-44f3e07cd497"
  },
  {
    id: "fs_007",
    name: "Oranges",
    description: "Pack of 8 premium Oranges",
    price: 19,
    img:"https://firebasestorage.googleapis.com/v0/b/react-http-51a82.appspot.com/o/fs_07.jpg?alt=media&token=be252539-e144-41df-8f6a-b149dc7c4f95"
  },
  {
    id: "fs_008",
    name: "Red Apple",
    description: "Pack of 3 premium Red Apples",
    price: 10,
    img:"https://firebasestorage.googleapis.com/v0/b/react-http-51a82.appspot.com/o/fs_08.jpg?alt=media&token=2026a7e5-5af2-4f65-8ae5-2176be86134f"
  },
  {
    id: "fs_009",
    name: "Strawberries",
    description: "Pack of 1 Kgs",
    price: 10,
    img:"https://firebasestorage.googleapis.com/v0/b/react-http-51a82.appspot.com/o/fs_09.jpg?alt=media&token=7ff22e58-5348-412e-a83d-fb161a337a7c"
  },
];

const ProductList = () => {
  return (
    <section className="bg-white py-8">
      <div className="container mx-auto flex items-center flex-wrap pt-4 pb-12">
        {DUMMY_PRODUCTS.map((product) => (
          <ProductCard name={product.name} price={product.price} imgurl={product.img} key={product.id}></ProductCard>
        ))}
      </div>
    </section>
  );
};

export default ProductList;
