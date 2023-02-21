import React, { useEffect, useState } from 'react'
import { useDispatch } from 'react-redux'
import { setModalData } from '../../redux/reducers/modal-reducer'
import './make-transfer-form.scss'
import { getAccounts } from './selectors'

function MakeTransferForm() {
	const dispatch = useDispatch()
	const accounts = getAccounts()

	const [senderAccountNumber, setSenderAccountNumber] = useState(accounts[0].accountNumberNoSpace)
	const [recipientAccountNumber, setRecipientAccountNumber] = useState()
	const [amount, setAmount] = useState()
	const [title, setTitle] = useState()

	useEffect(() => {
		dispatch(setModalData({
			senderAccountNumber,
			recipientAccountNumber,
			amount,
			title
		}))
	}, [senderAccountNumber, recipientAccountNumber, amount, title])
	return (
		<>
			<h5 className='make-transfer-title'>From</h5>
			<select onChange={(e) => setSenderAccountNumber(e.target.value)}>
				{
					accounts.filter(x => x.status !== 'Locked').map(account => {
						return (
							<option key={account.accountNumberNoSpace} value={account.accountNumberNoSpace}>{`${account.name} - ${account.balance} PLN`}</option>
						)
					})
				}
			</select>
			<h5 className='make-transfer-title'>To</h5>
			<input onChange={(e) => setRecipientAccountNumber(e.target.value)} placeholder='recipient acc. number' />
			<h5 className='make-transfer-title'>Amount</h5>
			<div>
				<input onChange={(e) => setAmount(e.target.value)} placeholder='0.00' />
				<span> PLN</span>
			</div>
			<h5 className='make-transfer-title'>Transfer title</h5>
			<input onChange={(e) => setTitle(e.target.value)} placeholder='Title' />
		</>
	)
}

export default MakeTransferForm