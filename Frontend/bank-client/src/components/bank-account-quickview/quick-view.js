import React from 'react'
import './quick-view.scss'

function BankAccountQuickview() {
	return(
		<div className='nb-account-quickview'>
			<div className='details'>
				<span className='type'>Business</span>
				<span className='name'>Sample account name</span>
				<span className='number'>1090 1014 0000 0712 1981 2874</span>
				<span className='amount'>4600.87 PLN</span>
			</div>
		</div>
	)
}

export default BankAccountQuickview