import React from "react";
import { Navbar } from "flowbite-react";

const Search = (props) => {
  return (
    <Navbar fluid={true} rounded={true}>
      <Navbar.Toggle />
      <input
        type="text"
        id="website-admin"
        className="rounded-none rounded-r-lg bg-gray-50 border border-gray-300 text-gray-900 focus:ring-blue-500 focus:border-blue-500 block flex-1 min-w-0 w-full text-sm border-gray-300 p-2.5  dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
        placeholder="Search Products here"
      />
    </Navbar>
  );
};
export default Search;
