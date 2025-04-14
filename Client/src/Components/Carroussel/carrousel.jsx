import React, { useState } from "react";
import right from "../../assets/right.png";
import left from "../../assets/left.png";
import "../Carroussel/carrousel.css";

function Carrousel({ slides }) {
	const [current, setCurrent] = useState(0);
	const cardsPerPage = 4;
	const length = slides.length;

	const nextSlide = () => {
		setCurrent((prev) =>
			prev + cardsPerPage >= length ? 0 : prev + cardsPerPage
		);
	};

	const prevSlide = () => {
		setCurrent((prev) =>
			prev - cardsPerPage < 0 ? Math.max(length - cardsPerPage, 0) : prev - cardsPerPage
		);
	};

	const visibleSlides = slides.slice(current, current + cardsPerPage);

	return (
		<section className="carrousel-container">
			{length > cardsPerPage && (
				<div className="carrousel-left" onClick={prevSlide}>
					<img src={left} alt="gauche" />
				</div>
			)}

			{length > cardsPerPage && (
				<div className="carrousel-right" onClick={nextSlide}>
					<img src={right} alt="droite" />
				</div>
			)}

			<div className="carrousel-content">
				{visibleSlides.map((Component, index) => (
					<div key={index} className="slider active">
						{Component}
					</div>
				))}
			</div>
		</section>
	);
}

export default Carrousel;
