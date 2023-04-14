import { createBrowserRouter, createRoutesFromElements, Route } from "react-router-dom";
import { CardsView } from './view/Cards'
import { SetsView } from './view/Sets'
import App from "./App";

export const router = createBrowserRouter( 
  createRoutesFromElements(
    <Route path='/' element={<App />}>
      <Route path='/sets' element={<SetsView />} />
      <Route path='/cards' element={<CardsView />} />
    </Route>
  )
);