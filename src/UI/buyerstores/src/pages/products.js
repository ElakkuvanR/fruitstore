import ProductList from "../components/Products/ProductList";
import { Navbar } from "flowbite-react";
import { AuthContextProvider } from "../store/auth-context";
import { Fragment } from "react";

const Products = (props) => {
  return (
    <AuthContextProvider>
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
    </AuthContextProvider>
  );
};

export default Products;
