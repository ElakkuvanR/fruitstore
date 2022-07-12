import React, { useContext } from "react";
import Header from "./components/Header/Header";
import Home from "./components/Home/home";
import Login from "./components/Login/Login";
import AuthContext from "./store/auth-context";
import { Redirect, Route, Switch } from "react-router-dom";
import Products from "./pages/products";
import Search from "./components/UI/Search/Search";

function App() {
  const ctx = useContext(AuthContext);
  return (
    <div className="container mx-auto">
      <Header></Header>
      <Search></Search>
      {!ctx.isLoggedIn && <Login></Login>}
      <Switch>
        <Route path="/products" exact>
          <Products></Products>
        </Route>
      </Switch>
    </div>
  );
}

export default App;
