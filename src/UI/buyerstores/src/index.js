import React from "react";
import ReactDOM from "react-dom/client";

import "./index.css";
import App from "./App";
import { AuthContextProvider } from "./store/auth-context";
import { Configuration } from "ordercloud-javascript-sdk";
import { BrowserRouter } from "react-router-dom";

Configuration.Set({
  baseApiUrl: "https://australiaeast-sandbox.ordercloud.io",
  timeoutInMilliseconds: 20 * 1000,
});

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <BrowserRouter>
    <AuthContextProvider>
      <App />
    </AuthContextProvider>
  </BrowserRouter>
);
