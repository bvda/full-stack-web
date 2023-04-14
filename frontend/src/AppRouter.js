import { createBrowserRouter, createRoutesFromElements, Route } from "react-router-dom";
import { CardsView } from './view/Cards'
import { SetsView } from './view/Sets'
import App from "./App";
import { CardView } from "./view/Card";
import { SetView } from "./view/Set";

export const router = createBrowserRouter( 
  createRoutesFromElements(
    <Route path='/' element={<App />}>
      <Route path='/sets' element={<SetsView />} />
      <Route path='/cards' element={<CardsView />} />
      <Route path='/card/:id' element={<CardView />} />
      <Route path='/sets/:id' element={<SetView />} />
    </Route>
  )
);