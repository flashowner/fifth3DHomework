### 改进飞碟游戏 <br>
这次作业的要求是改进飞碟游戏使它同时支持物理运动与运动学运动。<br>
物理学运动和运动学运动的差别在于，可以把运动学运动看作是理想化的运动，它不会受到外部作用力的影响，所以<br>
运动学的物体无法收到外力作用的，也就是说它不会受惯性和重力。而物理学运动，可以看作是物理上的运动，它在<br>
运动的时候会受到多个方面的影响，例如阻力的作用，重力的作用。<br>
在unity中，运动学和物理学的具体体现是在rigidbody组件上，当勾选isKinematic属性的时候，物体就会被当做<br>
是运动学，在物理学和运动学同时存在时，优先体现运动学，组件如图所示：<br>
![](https://github.com/flashowner/fifth3DHomework/blob/master/%E6%88%AA%E5%9B%BE/%E6%8D%95%E8%8E%B7.PNG)<br>
而在scipt中要想实现运动学和物理学的转换也十分简单，只要设定转换的条件，比如说按下一个按键，可以用Input.<br>
getKeyDown(Keycode.Space)来判断是否是按下一个按键,然后只需要再设置一下飞碟就可以了：this.getComponen<br>
t<Rigidbody>().isKinematic = true;<br>
因为物理学和运动学的代码其实是差不多的，也就是说在两种情况下飞碟的运动函数是差不多一样的，因此为了更好的<br>
组织代码需要使用adapter适配器模式，Adapter模式主要应用于"希望复用一些现存的类，但是接口又和复用环境要求<br>
不一致的情况"，在遗留代码复用，类库迁移等方法非常有效。A编写了一套数据，B也编写了一套数据，两个人的实现目<br>
的相同，结构相同，但就是名字不一样。这时候A要把B的代码结合到自己的程序中，如A制作了几个敌人攻击类，里<br>
面都有Attack方法，通过循环把全部敌人的Attack方法调用。B也制作了一个敌人类，但是B的敌人类的方法不是Attack<br>
方法，叫Hit方法，那这时怎么办呢，可能你会说把B的方法名字改一下不就好了，那如果B写的代码很多，修改起来很复<br>
杂，又或者这时候CDEF又有新的类需要接入过来呢，几十个人共同开发的话那不就得累死人了么。这时候就用得上<br>
Adapter 适配器模式了，简单的说，Adapter 适配器模式就像我们生活中的转接头一样，相当于实现了一个转接头，把<br>
各种不同的插头，统一转换过来，并改造成适合我们使用的类。<br>
所以可以将物理运动的类和运动学的类都用一个适配器封装，这样调用的时候只需要调用一个相同的接口即可。<br>

### 打靶游戏<br>
在这个打靶游戏中，游戏只有一轮而一轮中可以射无数次箭，首先在游戏开始的时候可以看到左上角的提示：<br>
![](https://github.com/flashowner/fifth3DHomework/blob/master/%E6%88%AA%E5%9B%BE/%E6%8D%95%E8%8E%B71.PNG)<br>
其中箭囊满表示可以射箭，箭囊空表示不能射箭，在这里，箭囊在射出一支箭后会显示成空的状态，等待<br>
3秒后，自动销毁，才会重新显示成满的状态，这时候才可以继续射箭。在游戏一开始的时候，通过鼠标<br>
点击生成箭，然后通过wsad可以移动箭才确定要射出的方向，可以看到箭囊下有力量，在射箭之前可以<br>
通过按j键来调整射箭的力量，力量的最大上限是199超过会从头开始。等设置完后按下空格键射箭。<br>
当箭射到靶上时会停住不动，从里到外的环数分别是54321环，射中后会获得对应的分数分数显示在<br>
坐上角。<br>
击中靶子的实现：<br>
![](https://github.com/flashowner/fifth3DHomework/blob/master/%E6%88%AA%E5%9B%BE/%E6%8D%95%E8%8E%B72.PNG)<br>
鼠标点击生成箭和移动箭：<br>
![](https://github.com/flashowner/fifth3DHomework/blob/master/%E6%88%AA%E5%9B%BE/%E6%8D%95%E8%8E%B73.PNG)<br>)<br>
![](https://github.com/flashowner/fifth3DHomework/blob/master/%E6%88%AA%E5%9B%BE/%E6%8D%95%E8%8E%B74.PNG)<br>
箭囊控制和自动销毁箭：<br>
![](https://github.com/flashowner/fifth3DHomework/blob/master/%E6%88%AA%E5%9B%BE/%E6%8D%95%E8%8E%B75.PNG)<br>
箭在射出后会受到一个一帧时间里由力产生的速度和重力<br>
游戏运行场景：<br>
![](https://github.com/flashowner/fifth3DHomework/blob/master/%E6%88%AA%E5%9B%BE/%E6%8D%95%E8%8E%B76.PNG)<br>
代码传送门：<br>
<br>
![飞碟游戏](https://github.com/flashowner/fifth3DHomework/tree/master/UFO)<br>
![射箭游戏](https://github.com/flashowner/fifth3DHomework/tree/master/Arrow)<br>
视频传送门：<br>
飞碟游戏：<br>
http://v.youku.com/v_show/id_XMzU0NTc4Mjg5Mg==.html?spm=a2h0j.11185381.listitem_page1.5!2~A<br>
射箭游戏：<br>
http://v.youku.com/v_show/id_XMzU2MjQ2MjIxNg==.html?spm=a2hzp.8253869.0.00<br>
