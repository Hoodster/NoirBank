import React, { useState } from 'react'
import CardPreview from '../../components/card/card-preview'
import './add-card-form.scss'

function AddCardForm() {
	const [cardStyle, setCardStyle] = useState('card1')
	const cards = [
		'card1',
		'card2',
		'card3',
		'card4'
	]
	return (
		<>
			<h5 className='add-card-title'>Card type</h5>
			<select className='add-card-select'>
				<option value={'debit'}>Debit</option>
				<option value={'credit'}>Credit</option>
			</select>
			<h5 className='add-card-title'>Assigned account</h5>
			<select className='add-card-select'>
				<option value={'1'}>Account 1</option>
				<option value={'2'}>Account 2</option>
				<option value={'3'}>Account 3</option>
				<option value={'4'}>Account 4</option>
				<option value={'5'}>Account 5</option>
				<option value={'6'}>Account 6</option>
			</select>
			<h5 className='add-card-title'>Card design</h5>
			<div className='card-patterns'>
				{
					cards.map((card) => {
						return (
							<div key={card} className='card-radio-wrapper card-type'>
								<div onClick={() => setCardStyle(card)}>
									<CardPreview cardStyle={`${card} card-sm`} />
								</div>
								<label htmlFor={card}>
									<span data-isEnabled={cardStyle === card} className='nb-ico'>checkmark</span>
								</label>
							</div>
						)
					})
				}
			</div>
		</>
	)
}

export default AddCardForm