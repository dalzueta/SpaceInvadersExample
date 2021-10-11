using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NewTestScript
    {
        private GameObject _go;
        private Rigidbody2D _rb;
        private Vector2 _oldPosition;
        private Translator _translator;

        // A Test behaves as an ordinary method
        [SetUp]
        public void Setup()
        {
            _go = new GameObject();
            _rb = _go.AddComponent<Rigidbody2D>();
            _rb.gravityScale = 0;
            _oldPosition = _go.transform.position;
            _translator = _go.AddComponent<Translator>();
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator GivenZeroMovementVectorTheGameObjectStaysInPlace()
        {
            yield return null; //Wait for Start Event

            //Act
            _translator.Move(Vector2.zero);

            yield return new WaitForSeconds(2f);

            // Assert
            Assert.AreEqual(_oldPosition, (Vector2)_go.transform.position);
        }

        [UnityTest]
        public IEnumerator GivenNonZeroMovementVectorTheGameObjectMovesAsExpected()
        {
            yield return null; //Wait for Start Event

            //Act
            _translator.Move(Vector2.right);

            yield return new WaitForSeconds(1f); //Wait for velocity to take place

            var newPosition = _go.transform.position;

            //Assert 

            Assert.AreEqual(_oldPosition.y, newPosition.y);
            Assert.IsTrue(Mathf.Approximately(1f, _go.transform.position.x), "can not approxime to 1f");
        }

        [UnityTest]
        public IEnumerator GivenMovementsOnBothDirectionsVectorTheGameObjectMovesAsExpected()
        {
            yield return null; //Wait for Start Event

            //Act
            _translator.Move(new Vector2(1f, 1f));

            yield return new WaitForSeconds(1f); //Wait for velocity to take place

            var newPosition = _go.transform.position;

            //Assert 
            Assert.IsTrue(Mathf.Approximately(1f, newPosition.x));
            Assert.IsTrue(Mathf.Approximately(1f, newPosition.y));
        }

        [UnityTest]
        public IEnumerator GivenAMovementTheVelocityIncreases()
        {
            yield return null; //Wait for Start Event
            //Act
            _translator.Move(Vector2.right);

            yield return new WaitForSeconds(1f);

            var positionAt1sec = _go.transform.position;

            yield return new WaitForSeconds(5f);

            var positionAt6Sec = _go.transform.position;

            Assert.IsTrue(positionAt6Sec.x > positionAt1sec.x);
        }
    }


}
