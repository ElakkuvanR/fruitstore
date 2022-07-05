import React, { useContext } from "react";
import Header from "./components/Header/Header";
import Home from "./components/Home/home";
import Login from "./components/Login/Login";
import AuthContext from "./store/auth-context";
import { Redirect, Route, Switch } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import Products from "./pages/products";

function App() {
  const ctx = useContext(AuthContext);
  return (
    <React.Fragment>
      <Header></Header>
      {!ctx.isLoggedIn && <Login></Login>}
      <Switch>
        <Route path="/products" exact>
          <Products></Products>
        </Route>
      </Switch>
    </React.Fragment>
  );
}

export default App;
