import ProductList from "../components/Products/ProductList";
import { Navbar } from "flowbite-react";
import { Fragment } from "react";

const Products = (props) => {
  return (
    <Fragment>
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
    </Fragment>
  );
};

export default Products;
