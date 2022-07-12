import { Navbar, Dropdown, Avatar } from "flowbite-react";
import Search from "../UI/Search/Search";
import styles from "./NavigationBar.module.css";
import NavDropDown from "./NavigationDropDown";

const NavigationBar = (props) => {
  return (
    <Navbar fluid={true} rounded={true}>
      <Navbar.Brand href="/">
        <img
          src="/fruits.png"
          className="mr-3 h-6 sm:h-9"
          alt="Flowbite Logo"
        />
        <span className="self-center whitespace-nowrap text-xl font-semibold dark:text-white">
          Fruit Store with OrderCloud
        </span>
      </Navbar.Brand>
      <div className="flex md:order-2">
        <NavDropDown></NavDropDown>
        <Navbar.Toggle />
      </div>
      <Navbar.Toggle />
      <Navbar.Collapse>
        <Navbar.Link href="/navbars" active={true}>
          Home
        </Navbar.Link>
        <Navbar.Link href="/about">About</Navbar.Link>
        <Navbar.Link href="/products">Products</Navbar.Link>
      </Navbar.Collapse>
    </Navbar>
  );
};

export default NavigationBar;
