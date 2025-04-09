import CarNewTrajet from "../CardNewTrajet/CardNewTrajet";
import Carrousel from "../Carroussel/carrousel";

function NewTrajet() {
	const slides = [
		<CarNewTrajet townD="Paris" townA="Marseille"date="25/10/2025" place="3" departure="15h00" arrive="23h00" />,
		<CarNewTrajet townD="Paris" townA="Marseille"date="26/10/2025" place="2" departure="12h00" arrive="18h00" />,
		<CarNewTrajet townD="Paris" townA="Marseille" date="27/10/2025" place="4" departure="09h00" arrive="17h00" />,
		<CarNewTrajet townD="Paris" townA="Marseille" date="28/10/2025" place="1" departure="08h00" arrive="10h00" />
	];

	return (
		<div className="carnew-component">
			<div className="carnew-title">
				<div className="icon-cheese">{/* ton SVG gauche */}</div>
				<h3 className="title">NOUVEAUX TRAJETS</h3>
				<div className="icon-cheese">{/* ton SVG droite */}</div>
			</div>

			<div className="card-bloq">
				<Carrousel slides={slides} />
			</div>
		</div>
	);
}

export default NewTrajet;
