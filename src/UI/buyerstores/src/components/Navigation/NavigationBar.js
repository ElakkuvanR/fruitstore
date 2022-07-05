import { Navbar, Container, Nav } from "react-bootstrap";
import { Link } from "react-router-dom";
import Search from "../UI/Search/Search";
import styles from "./NavigationBar.module.css";
import NavigationDropDown from "./NavigationDropDown";
import { LinkContainer } from "react-router-bootstrap";
const NavigationBar = (props) => {
  return (
    <Navbar bg="dark" variant="dark" expand="lg">
      <Container>
        <LinkContainer to="">
          <Navbar.Brand href="#" style={{ fontSize: "xx-large" }}>
            Fruit Store
          </Navbar.Brand>
        </LinkContainer>
        <Navbar.Toggle aria-controls="navbarScroll" />
        <Navbar.Collapse id="navbarScroll">
          <Nav
            className="me-auto my-2 my-lg-0"
            style={{ maxHeight: "100px" }}
            navbarScroll
          >
            <LinkContainer to="/products">
              <Nav.Link className={styles.navtext}>Products</Nav.Link>
            </LinkContainer>
          </Nav>
          <Search></Search>
          <NavigationDropDown></NavigationDropDown>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default NavigationBar;
