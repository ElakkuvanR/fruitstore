import { Navbar, Container, Nav } from "react-bootstrap";
import Search from "../UI/Search/Search";
import styles from "./NavigationBar.module.css";
import NavigationDropDown from "./NavigationDropDown";
const NavigationBar = (props) => {
  return (
    <Navbar bg="dark" variant="dark" expand="lg">
      <Container>
        <Navbar.Brand href="#"></Navbar.Brand>
        <Navbar.Toggle aria-controls="navbarScroll" />
        <Navbar.Collapse id="navbarScroll">
          <Nav
            className="me-auto my-2 my-lg-0"
            style={{ maxHeight: "100px" }}
            navbarScroll
          >
            <Nav.Link href="#action1" className={styles.navtext}>
              Home
            </Nav.Link>
            <Nav.Link href="#action2" className={styles.navtext}>
              Products
            </Nav.Link>
          </Nav>
          <Search></Search>
          <NavigationDropDown></NavigationDropDown>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default NavigationBar;