import ProductList from "../components/Products/ProductList";
import { Navbar } from "flowbite-react";
import React, { Fragment } from "react";

const Products = (props) => {
  return (
    <React.Fragment>
      <Navbar fluid={true} rounded={true}>
        <Navbar.Toggle />
        <Navbar.Collapse>
          <Navbar.Link href="/products" active={true}>
            All Products
          </Navbar.Link>
        </Navbar.Collapse>
      </Navbar>
      <div className="container mx-auto">
        <ProductList></ProductList>
      </div>
    </React.Fragment>
  );
};

export default Products;
