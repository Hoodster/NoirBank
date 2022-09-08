import React, { useEffect, useState } from 'react'
import { useDispatch } from 'react-redux'
import CardPreview from '../../components/card/card-preview'
import { setModalData } from '../../redux/reducers/modal-reducer'
import './add-card-form.scss'
import { getAccounts } from './selectors'

function AddCardForm() {
	const dispatch = useDispatch()

	const accounts = getAccounts()

	const [cardStyle, setCardStyle] = useState('card1')
	const [cardType, setCardType] = useState('Debit')
	const [account, setAccount] = useState(accounts[0].accountNumberNoSpace)

	const setCardData = () => {
		dispatch(setModalData({ cardStyle, cardType, account }))
	}

	useEffect(() => {
		setCardData()
	}, [])

	useEffect(() => {
		setCardData()
	}, [cardStyle, cardType, account])

	const cards = [
		'card1',
		'card2',
		'card3',
		'card4'
	]

	return (
		<>
			<h5 className='add-card-title'>Card type</h5>
			<select className='add-card-select' onChange={e => setCardType(e.target.value)}>
				<option value={'Debit'}>Debit</option>
				<option value={'Credit'}>Credit</option>
			</select>
			<h5 className='add-card-title'>Assigned account</h5>
			<select className='add-card-select' onChange={e => setAccount(e.target.value)}>
				{
					accounts.filter(account => account.status !== 'Locked').map(account => <option key={account.accountNumberNoSpace} value={account.accountNumberNoSpace}>{account.name}</option>)
				}
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
									<span data-isenabled={cardStyle === card} className='nb-ico'>checkmark</span>
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