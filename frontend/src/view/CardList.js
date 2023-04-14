import { Link } from "react-router-dom";

export function CardList({items}) {
    return (
      <ul>
        {items.map(c => (
          <li key={c.name}><Link to={`/card/${c.id}`}>{c.name}</Link></li>
        ))}
      </ul>
    );
  }