import { Link } from "react-router-dom";

export function CardListItem({card}) {
  return <Link to={`/card/${card.id}`}>{card.name}</Link>
}