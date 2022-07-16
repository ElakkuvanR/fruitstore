import React, { useState, useEffect } from "react";
import { Auth, Tokens, Me } from "ordercloud-javascript-sdk";
import { AppConfig } from "../configs/appconfig";
import { EnvironmentConfig } from "../environments/environmentconfig";

const AuthContext = React.createContext({
  isLoggedIn: false,
  onLogout: () => {},
  onLogin: (email, password) => {},
  authToken: "",
  loggedinUser: null,
});

export const AuthContextProvider = (props) => {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [userAuthToken, setUserAuthToken] = useState("");
  const [me, setMe] = useState(null);

  useEffect(() => {
    const storedUserLoggedInInformation = localStorage.getItem("authtoken");

    if (storedUserLoggedInInformation) {
      setIsLoggedIn(true);
      setUserAuthToken(storedUserLoggedInInformation);
      Me.Get().then((response) => {
        setMe(response);
      });
    }
  }, []);

  const logoutHandler = () => {
    localStorage.removeItem("authtoken");
    setMe(null);
    setUserAuthToken("");
    setIsLoggedIn(false);
  };

  const loginHandler = (username, password) => {
    setIsLoggedIn(true);
    const clientID = EnvironmentConfig.buyerClientId;
    const scope = AppConfig.shopperScope;
    Auth.Login(username, password, clientID, scope)
      .then((response) => {
        const token = response.access_token;
        Tokens.SetAccessToken(token);
        setUserAuthToken(token);
        localStorage.setItem("authtoken", token);
        Me.Get().then((response) => {
          setMe(response);
        });
      })
      .catch((err) => console.log(err));
  };

  return (
    <AuthContext.Provider
      value={{
        isLoggedIn: isLoggedIn,
        onLogout: logoutHandler,
        onLogin: loginHandler,
        authToken: userAuthToken,
        loggedinUser: me,
      }}
    >
      {props.children}
    </AuthContext.Provider>
  );
};

export default AuthContext;
