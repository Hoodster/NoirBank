import React, { useEffect, useState } from 'react'
import { useDispatch } from 'react-redux'
import CardPreview from '../../components/card/card-preview'
import { setModalData } from '../../redux/reducers/modal-reducer'
import styles from './add-card-form.module.scss'
import { getAccounts } from './selectors'
import clsx from 'clsx'

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
			<h5 className={styles['add-card-title']}>Card type</h5>
			<select className={styles['add-card-select']} onChange={e => setCardType(e.target.value)}>
				<option value={'Debit'}>Debit</option>
				<option value={'Credit'}>Credit</option>
			</select>
			<h5 className={styles['add-card-title']}>Assigned account</h5>
			<select className={styles['add-card-select']} onChange={e => setAccount(e.target.value)}>
				{
					accounts.filter(account => account.status !== 'Locked').map(account => <option key={account.accountNumberNoSpace} value={account.accountNumberNoSpace}>{account.name}</option>)
				}
			</select>
			<h5 className={styles['add-card-title']}>Card design</h5>
			<div className={styles['card-patterns']}>
				{
					cards.map((card) => {
						return (
							<div key={card} className={clsx(styles['card-radio-wrapper'], styles['card-type'])}>
								<div onClick={() => setCardStyle(card)}>
									<CardPreview cardStyle={card} cardSize={'card-sm'} />
								</div>
								<label htmlFor={card}>
									<span data-isenabled={cardStyle === card} className={styles['nb-ico']}>checkmark</span>
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