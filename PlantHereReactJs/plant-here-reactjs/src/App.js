// React
import React from 'react';
import { RouterProvider } from "react-router-dom";

// Router
import router from './router';

function App() {
  return (
    <RouterProvider router={router} />
  );
}

export default App;
